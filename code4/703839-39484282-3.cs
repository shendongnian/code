    using System.Resources;
    namespace System.ComponentModel
    {
        public class LocalisedDisplayNameAttribute
            : DisplayNameAttribute
        {
            readonly ResourceManager m_resourceManager;
            readonly string          m_resourceName;
            public LocalisedDisplayNameAttribute(ResourceManager resourceManager,
                                                 string          resourceName)
                : base()
            {
                m_resourceManager = resourceManager;
                m_resourceName    = resourceName;
            }
            public override string DisplayName
            {
                get { return m_resourceManager.GetString(m_resourceName); }
            }
        }
    }
