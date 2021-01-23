    public class GovMsgHeader : MessageHeader {
        protected override void OnWriteStartHeader(
            System.Xml.XmlDictionaryWriter writer,
            MessageVersion messageVersion) {
            base.OnWriteStartHeader(writer, messageVersion);
            // Write you custom XML using the XmlDictionaryClass:
            //TODO: add the 'param' XML namespace to the writer...
            //TODO: add the container element with something like this:
            writer.WriteElementString("SaglikNetParameters", "param", "");
            writer.WriteElementString("parameter", "param", "2");
            writer.WriteAttributeString("name", "", "islemKodu");
            //TODO: complete the rest of the XML ...
        }
    }
