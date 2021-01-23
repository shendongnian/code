    using System;
    using System.Windows.Forms;
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Shared;
    
    namespace WindowsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load("PUT CRYSTAL REPORT PATH HERE\CrystalReport1.rpt");
    
                ParameterFieldDefinitions crParameterFieldDefinitions ;
                ParameterFieldDefinition crParameterFieldDefinition ;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
    
                crParameterDiscreteValue.Value = dataGridView1.SelectedRows[0].Cells["payment_id"].Value.ToString();;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["payment_id"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
    
                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
    
                crystalReportViewer1.ReportSource = cryRpt;
                crystalReportViewer1.Refresh(); 
    
            }
        }
    }
