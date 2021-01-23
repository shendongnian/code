      label2.Text = Convert.ToString(BAssistencia.nroo);
            ReportDocument oRep = new ReportDocument();
            ParameterField campo = new ParameterField();
            ParameterFields campo2 = new ParameterFields();
            ParameterDiscreteValue Pdv = new ParameterDiscreteValue();
    
            campo.Name = "@pedido";
            Pdv.Value = label2.Text;
            campo.CurrentValues.Add(Pdv);
            campo2.Add(campo);
            crystalReportViewer1.ParameterFieldInfo = campo2;
            oRep.Load("C:/Relatorios/CrystalReport3.rpt");
            oRep.SetDatabaseLogon("sa","password","server","database");
            crystalReportViewer1.ReportSource = oRep;
        
