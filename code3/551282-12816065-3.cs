        public static void SaveFile(BusinessObject document)
        {
            Byte[] content = document.Content;
            // do something with content.
        }
    This is only true if `Content` is defined on `BusinessObject` and not only on derived classes.
