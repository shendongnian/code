    using System;
    using System.Xml.Serialization;
    using System.IO;
    namespace DEMO.Common
    {
    public class DTOSerializerHelper
    {
        public DTOSerializerHelper()
        {
        }
        /// 
        /// Creates xml string from given dto.
        /// 
        /// DTO
        /// XML
        public static string SerializeDTO(DTO dto)
        {
            try
            {
                XmlSerializer xmlSer = new XmlSerializer(dto.GetType());
                StringWriter sWriter = new StringWriter();
                // Serialize the dto to xml.
                xmlSer.Serialize(sWriter, dto);
                // Return the string of xml.
                return sWriter.ToString();
            }
            catch(Exception ex)
            {
                // Propogate the exception.
                throw ex;
            }
        }
        /// 
        /// Deserializes the xml into a specified data transfer object.
        /// 
        /// string of xml
        /// type of dto
        /// DTO
        public static DTO DeserializeXml(string xml, DTO dto)
        {
            try
            {
                XmlSerializer xmlSer = new XmlSerializer(dto.GetType());
                // Read the XML.
                StringReader sReader = new StringReader(xml);
                // Cast the deserialized xml to the type of dto.
                DTO retDTO = (DTO)xmlSer.Deserialize(sReader);
                // Return the data transfer object.
                return retDTO;
            }
            catch(Exception ex)
            {
                // Propogate the exception.
                throw ex;
            }            
        }
    }
