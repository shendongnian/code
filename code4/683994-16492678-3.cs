    using Microsoft.VisualStudio.Language.StandardClassification;
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    namespace VSIXProject1
    {
        internal static class MyLangLanguage
        {
            public const string ContentType = "mylang";
            public const string FileExtension = ".mylang";
            [Export]
            [Name(ContentType)]
            [BaseDefinition("code")]
            internal static ContentTypeDefinition MyLangSyntaxContentTypeDefinition = null;
            [Export]
            [FileExtension(FileExtension)]
            [ContentType(ContentType)]
            internal static FileExtensionToContentTypeDefinition MyLangSyntaxFileExtensionDefinition = null;
        }
        [Export(typeof(IClassifierProvider))]
        [ContentType(MyLangLanguage.ContentType)]
        [Name("MyLangSyntaxProvider")]
        internal sealed class MyLangSyntaxProvider : IClassifierProvider
        {
            [Import]
            internal IClassificationTypeRegistryService ClassificationRegistry = null;
            public IClassifier GetClassifier(ITextBuffer buffer)
            {
                return buffer.Properties.GetOrCreateSingletonProperty(() => new MyLangSyntax(ClassificationRegistry, buffer));
            }
        }
        internal sealed class MyLangSyntax : IClassifier
        {
            private ITextBuffer buffer;
            private IClassificationType identifierType;
            private IClassificationType keywordType;
            public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;
            internal MyLangSyntax(IClassificationTypeRegistryService registry, ITextBuffer buffer)
            {
                this.identifierType = registry.GetClassificationType(PredefinedClassificationTypeNames.Identifier);
                this.keywordType = registry.GetClassificationType(PredefinedClassificationTypeNames.Keyword);
                this.buffer = buffer;
                this.buffer.Changed += OnBufferChanged;
            }
            public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan snapshotSpan)
            {
                var classifications = new List<ClassificationSpan>();
                string text = snapshotSpan.GetText();
                var span = new SnapshotSpan(snapshotSpan.Snapshot, snapshotSpan.Start.Position, text.Length);
                classifications.Add(new ClassificationSpan(span, keywordType));
                return classifications;
            }
            private void OnBufferChanged(object sender, TextContentChangedEventArgs e)
            {
                foreach (var change in e.Changes)
                    ClassificationChanged(this, new ClassificationChangedEventArgs(new SnapshotSpan(e.After, change.NewSpan)));
            }
        }
    }
