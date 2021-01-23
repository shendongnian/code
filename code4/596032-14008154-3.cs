    using System.Xml;
    using System.Xml.Linq;
    var doc = XDocument.Parse(trx.GetCardTrx("xxxxx", "xxxx", "xxx", "", dateTimePicker1.Text, dateTimePicker2.Text, "", "", "", "", "", "", "", "", "", "", "", "FALSE", "", "", "", "", "", "", "", "", "", "", ""));
      var data = new DataSet();
      var context = new XmlParserContext(null, new XmlNamespaceManager(new NameTable()), null, XmlSpace.None);
      var reader = doc
      data.ReadXml(reader);
    
      var report = new ReportDocument();
      
      report.SetDataSource(data);
      this.crystalReportViewer1.ReportSource.ReportSource = report;
