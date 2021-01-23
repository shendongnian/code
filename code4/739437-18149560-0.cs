    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;
    namespace CustomControls
    {
        [ParseChildren(true)]
        [PersistChildren(false)]
        public class VersionedContent : Control
        {
            public string VersionToUse { get; set; }
            [PersistenceMode(PersistenceMode.InnerProperty)]
            [TemplateContainer(typeof(ContentContainer))]
            [TemplateInstance(TemplateInstance.Multiple)]
            public List<Content> ContentVersions { get; set; }
            public override ControlCollection Controls
            {
                get
                {
                    EnsureChildControls();
                    return base.Controls;
                }
            }
            public ContentContainer ContentContainer
            {
                get
                {
                    EnsureChildControls();
                    return _contentContainer;
                }
            } private ContentContainer _contentContainer;
            protected override void CreateChildControls()
            {
                var controlToUse = ContentVersions.Single(x => x.Version == VersionToUse);
                Controls.Clear();
                _contentContainer = new ContentContainer();
                controlToUse.InstantiateIn(_contentContainer);
                Controls.Add(_contentContainer);
            }
        }
        public class Content : Control, ITemplate
        {
            public string Version { get; set; }
            public void InstantiateIn(Control container)
            {
                container.Controls.Add(this);
            }
        }
        public class ContentContainer : Control { }
    }
