    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace XMLSerializationTest
    {
        [Serializable, XmlRoot("delayedquotes"), XmlType("delayedquotes")]
        public class delayedquotes
        {
            [XmlElement("instrument")]
            public string instrument { get; set; }
            [XmlElement("title")]
            public string title { get; set; }
            [XmlElement("bid")]
            public double bid { get; set; }
            [XmlElement("spot")]
            public double spot { get; set; }
            [XmlElement("close")]
            public double close { get; set; }
            [XmlElement("b_time")]
            public DateTime b_time { get; set; }
            [XmlElement("o_time")]
            public DateTime o_time { get; set; }
            [XmlElement("time")]
            public DateTime time { get; set; }
            [XmlElement("hi")]
            public string hi { get; set; }
            [XmlElement("lo")]
            public string lo { get; set; }
            [XmlElement("offer")]
            public double offer { get; set; }
            [XmlElement("trade")]
            public double trade { get; set; }
            public delayedquotes()
            {
            }
        }
        static class Program
        {
            static void Main(string[] args)
            {
                string source = @"<delayedquotes id=""TestData""> 
      <headings> 
        <title/> 
        <bid>bid</bid> 
        <offer>offer</offer> 
        <trade>trade</trade> 
        <close>close</close> 
        <b_time>b_time</b_time> 
        <o_time>o_time</o_time> 
        <time>time</time> 
        <hi.lo>hi.lo</hi.lo> 
        <perc>perc</perc> 
        <spot>spot</spot> 
      </headings> 
      <instrument id=""Test1""> 
        <title id=""Test1"">Test1</title> 
        <bid>0</bid> 
        <offer>0</offer> 
        <trade>0</trade> 
        <close>0</close> 
        <b_time>11:59:00</b_time> 
        <o_time>11:59:00</o_time> 
        <time>11:59:00</time> 
        <perc>0%</perc> 
        <spot>0</spot> 
      </instrument> 
    </delayedquotes> 
    ";
                var buff = Encoding.ASCII.GetBytes(source);
                var ms = new MemoryStream(buff);
                var xs = new XmlSerializer(typeof(delayedquotes));
                var o = (delayedquotes)xs.Deserialize(ms);
                Console.WriteLine("Title = {0}", o.instrument);
            }
        }
    }
