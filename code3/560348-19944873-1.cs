    namespace Schemas1
    {
        using System;
        using System.Diagnostics;
        using System.Xml.Serialization;
        using System.Collections;
        using System.Xml.Schema;
        using System.ComponentModel;
        using System.Collections.Generic;
        public partial class UITranslatorConfiguration
        {
            private List<Query> queriesField;
            public UITranslatorConfiguration()
            {
                this.queriesField = new List<Query>();
            }
            public List<Query> Queries
            {
                get
                {
                    return this.queriesField;
                }
                set
                {
                    this.queriesField = value;
                }
            }
        }
        public partial class Query
        {
            private string queryIDField;
            private string valueField;
            public string QueryID
            {
                get
                {
                    return this.queryIDField;
                }
                set
                {
                    this.queryIDField = value;
                }
            }
            [System.Xml.Serialization.XmlTextAttribute()]
            public string Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }
    }
