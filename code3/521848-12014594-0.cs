    [XmlRoot( "Harvey" )]
    public class Widget
    {
        [XmlElement]
        public string Name { get ; set; }
        [XmlElement]
        public string Ch   { get ; set; }
        [XmlElement]
        public int    Tn   { get ; set; }
        [XmlArray("APoints")]
        [XmlArrayItem("int")]
        public int[] APoints { get ; set ; }
        [XmlArray("SPoints")]
        [XmlArrayItem("int")]
        public int[] SPoints { get ; set ; }
    }
    class Program
    {
        public static T Rehydrate<T>( string xml )
        {
            T instance ;
            XmlSerializer serializer = new XmlSerializer( typeof(T) ) ;
            using ( TextReader tr = new StringReader( xml ) )
            {
                instance = (T) serializer.Deserialize( tr ) ;
            }
            return instance ;
        }
        static void Main( string[] args )
        {
            string xml = @"
    <Harvey xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
      <Name>Carl</Name>
      <Ch>KNV</Ch>
      <Tn>40</Tn>
      <APoints>
        <int>8</int>
        <int>20</int>
        <int>16</int>
        <int>16</int>
        <int>12</int>
        <int>12</int>
        <int>16</int>
        <int>16</int>
        <int>4</int>
        <int>4</int>
        <int>4</int>
      </APoints>
      <SPoints>
        <int>3</int>
        <int>12</int>
        <int>10</int>
        <int>10</int>
        <int>6</int>
        <int>6</int>
        <int>10</int>
        <int>10</int>
      </SPoints>
    </Harvey>
    ";
            Widget instance = Rehydrate<Widget>( xml ) ;
            return;
        }
    }
