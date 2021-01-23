    private static readonly Regex DTCheck = new Regex(@"(\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2})([\+|-]\d{2}:\d{2})");
        /// <summary>
        /// Removes any instances of the TimeZoneOffset from the RigX after it has been serialized into an XMLString ++ Called from the "Save" process
        /// </summary>
        /// <param name="rigx"></param>
        /// <returns>StringReader referencing the re-formatted XML String</returns>
        private static StringReader RemoveTZOffsetFromRigX(RigX rigx)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            XmlSerializer ser = new XmlSerializer(typeof(RigX));
            ser.Serialize(sw, rigx);
            string xmlText = sb.ToString();
            if (DTCheck.IsMatch(xmlText))
                xmlText = DTCheck.Replace(xmlText, "$1");
            StringReader Sreader = new StringReader(xmlText);
            return Sreader;
        }
        /// <summary>
        /// Removes the TimeZone offset from a RigX as referenced by stream.  Returns a reader linked to the new stream  ++ Called from the "Load" process
        /// </summary>
        /// <param name="stream">stream containing the initial RigX XML String</param>
        /// <returns>StringReader referencing the re-formatted XML String</returns>
        private StringReader RemoveTZOffsetFromXML(MemoryStream stream)
        {
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string xmlText = reader.ReadToEnd();
            reader.Close();
            stream.Close();
            if (DTCheck.IsMatch(xmlText))
                xmlText = DTCheck.Replace(xmlText, "$1");
            StringReader Sreader = new StringReader(xmlText);
            return Sreader;
        }
