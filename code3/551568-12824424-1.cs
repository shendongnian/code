    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration;
    
    namespace GP.Solutions.WF.DocumentProvider.Entities.SharePoint
    {
        /// <summary>
        /// Base SharePoint 2010 provider contiguration
        /// </summary>
        [Serializable]
        public class SharePoint2010Settings : ConfigurationSection
        {
            /// <summary>
            /// DocumentStorageRoot
            /// </summary>
            [ConfigurationProperty("SiteUrl", IsRequired = true, DefaultValue = "")]
            public string SiteUrl
            {
                get { return (string)base["SiteUrl"]; }
                set { base["SiteUrl"] = value; }
            }
    
            /// <summary>
            /// TitleProperty
            /// </summary>
            [ConfigurationProperty("TitleProperty", IsRequired = true, DefaultValue = "Title")]
            public string TitleProperty
            {
                get { return (string)base["TitleProperty"]; }
                set { base["TitleProperty"] = value; }
            }
    
            /// <summary>
            /// ProvideFileAsLink
            /// </summary>
            [ConfigurationProperty("ProvideFileAsLink", IsRequired = true, DefaultValue = true)]
            public bool ProvideFileAsLink
            {
                get { return (bool)base["ProvideFileAsLink"]; }
                set { base["ProvideFileAsLink"] = value; }
            }
    
            /// <summary>
            /// DocumentCategories
            /// </summary>
            [ConfigurationProperty("DocumentCategories")]
            public SharePointDocumentCategoryCollection DocumentCategories
            {
                get { return (SharePointDocumentCategoryCollection)base["DocumentCategories"]; }
                set { base["DocumentCategories"] = value; }
            }
    
        }
    
        /// <summary>
        /// Configuration element that holds SharePointDocumentCategory collection
        /// </summary>
        [ConfigurationCollection(typeof(SharePointDocumentCategory), AddItemName = "DocumentCategory", CollectionType = ConfigurationElementCollectionType.BasicMap)]
        public class SharePointDocumentCategoryCollection : ConfigurationElementCollection
        {
            protected override ConfigurationElement CreateNewElement()
            {
                return new SharePointDocumentCategory();
            }
    
            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((SharePointDocumentCategory)element).CategoryName;
            }
        }
    
        /// <summary>
        /// Configuration element that holds information for specific document category
        /// </summary>
        [Serializable]
        public class SharePointDocumentCategory: ConfigurationElement
        {
            /// <summary>
            /// CategoryName
            /// </summary>
            [ConfigurationProperty("CategoryName", IsRequired = true, DefaultValue = "")]
            public string CategoryName
            {
                get { return (string)base["CategoryName"]; }
                set { base["CategoryName"] = value; }
            }
    
            /// <summary>
            /// FolderName
            /// </summary>
            [ConfigurationProperty("FolderName", IsRequired = true, DefaultValue = "")]
            public string FolderName
            {
                get { return (string)base["FolderName"]; }
                set { base["FolderName"] = value; }
            }
    
    
            /// <summary>
            /// TitleProperty
            /// </summary>
            [ConfigurationProperty("OverwriteFiles", IsRequired = true, DefaultValue = true)]
            public bool OverwriteFiles
            {
                get { return (bool)base["OverwriteFiles"]; }
                set { base["OverwriteFiles"] = value; }
            }
    
            /// <summary>
            /// DocumentCategories
            /// </summary>
            [ConfigurationProperty("CategoryFields")]
            public SharePointCategoryFieldsCollection CategoryFields
            {
                get { return (SharePointCategoryFieldsCollection)base["CategoryFields"]; }
                set { base["CategoryFields"] = value; }
            }
    
        }
    
        /// <summary>
        /// Configuration element that holds SharePointDocumentCategory collection
        /// </summary>
        [ConfigurationCollection(typeof(SharePointDocumentCategory), AddItemName = "CategoryField", CollectionType = ConfigurationElementCollectionType.BasicMap)]
        public class SharePointCategoryFieldsCollection : ConfigurationElementCollection
        {
            protected override ConfigurationElement CreateNewElement()
            {
                return new SharePointCategoryField();
            }
    
            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((SharePointCategoryField)element).FieldName;
            }
        }
    
        /// <summary>
        /// Class that determines specific field
        /// </summary>
        [Serializable]
        public class SharePointCategoryField : ConfigurationElement
        {
            /// <summary>
            /// FolderName
            /// </summary>
            [ConfigurationProperty("FieldName", IsRequired = true, DefaultValue = "")]
            public string FieldName
            {
                get { return (string)base["FieldName"]; }
                set { base["FieldName"] = value; }
            }
        }
    
    }
