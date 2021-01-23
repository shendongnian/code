        public DownloadResponse downloadDataFile([System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] DownloadRequest Request) {
            RequireMtom = true; // ADDED
            object[] results = this.Invoke("downloadDataFile", new object[] {
                        Request});
            RequireMtom = false; // ADDED
            return ((DownloadResponse)(results[0]));
        }
