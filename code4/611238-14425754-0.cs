    private void ConvertFile()
    {
        try
        {
            PrepElec1();
            MakeElec2();
            MakeElec3();
            MakeElec4();
            MakeElecMerged();
            SetDataSet.SetData(DtSet);
            btnConvert.Enabled = false;
            btnReport.Visible = true;
        }
        catch (Exception e)
        {
            var trace = e.StackTrace;
            // format trace however you like
            MessageBox.Show(this, trace, "Error");
        }
    }
