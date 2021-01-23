    public class ConsultarSituacaoLoteRpsResposta
    {
        public int NumeroLote { set; get; }
        public int Situacao { set; get; }
        public List<MensagemRetorno> ListaMensagemRetorno { get; set; }
    }
    public class MensagemRetorno
    {
        public string Codigo { set; get; }
        public string Mensagem { set; get; }
        public string Correcao { set; get; }
    }
    XmlSerializer serializer = new XmlSerializer(typeof(ConsultarSituacaoLoteRpsResposta), "http://www.abrasf.org.br/ABRASF/arquivos/nfse.xsd");
    var obj1 = (ConsultarSituacaoLoteRpsResposta)serializer.Deserialize(new StringReader(xml1));
    var obj2 = (ConsultarSituacaoLoteRpsResposta)serializer.Deserialize(new StringReader(xml2));
