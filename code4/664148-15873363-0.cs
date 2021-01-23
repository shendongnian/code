        public class FileInfo
        {
            [DisplayName("Messages")]
            [Editor(typeof(MyCustomCollectionEditor), typeof(UITypeEditor))]
            public Collection<MessageInfo> MessageInfos { get; set; }
        }
        public class MyCustomCollectionEditor : CollectionEditor // needs a reference to System.Design.dll
        {
            public MyCustomCollectionEditor(Type type)
                : base(type)
            {
            }
            public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
            {
                if (DontShowForSomeReason(context)) // you need to implement this
                    return UITypeEditorEditStyle.None; // disallow edit (hide the small browser button)
                return base.GetEditStyle(context);
            }
        }
