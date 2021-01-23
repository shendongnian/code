    // get data from file
    XElement aucCars = XElement.Load("data.xml");
    private void cmbSeries_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbSeries.SelectedItem != null)
        {
            string currentSeries = cmbSeries.SelectedItem.ToString();
            var models = (from a in aucCars.Elements()
                            where a.Element("Web_Series").Value == currentSeries
                            select a.Element("Model_Type").Value).Distinct().ToList();
            cmbModel.DataSource = models;
        }
        showAucCars();
    }
    private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbModel.SelectedItem != null)
        {
            string currentSeries = cmbSeries.SelectedItem.ToString();
            string currentModel = cmbModel.SelectedItem.ToString();
            var years = (from a in aucCars.Elements()
                            where a.Element("Web_Series").Value == currentSeries &&
                            a.Element("Model_Type").Value == currentModel
                            select a.Element("Model_Year").Value).Distinct().ToList();
            cmbYear.DataSource = years;
        }
        showAucCars();
    }
    private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        showAucCars();
    }
    private void frmXmlLoad_Load(object sender, EventArgs e)
    {            
        var series = (from a in aucCars.Elements()
                    select a.Element("Web_Series").Value).Distinct().ToList();
        cmbSeries.DataSource = series;
    }
    private void showAucCars()
    {
        var filterCars = aucCars.Elements();
        if (cmbSeries.SelectedItem!=null)
        {
            string currentSeries = cmbSeries.SelectedItem.ToString();
            filterCars = from a in filterCars
                            where a.Element("Web_Series").Value == currentSeries
                            select a;
        }
        if (cmbSeries.SelectedItem != null)
        {
            string currentModel = cmbModel.SelectedItem.ToString();
            filterCars = from a in filterCars
                            where a.Element("Model_Type").Value == currentModel
                            select a;
        }
        if (cmbSeries.SelectedItem != null)
        {
            string currentYear = cmbYear.SelectedItem.ToString();
            filterCars = from a in filterCars
                            where a.Element("Model_Year").Value == currentYear
                            select a;
        }
        // will show all the element data 
        // add a new linq stmt to select specific elements
        listBox1.DataSource = filterCars.ToList();            
    }
