    private void ReadPositions() {
        TextReader tr = new StreamReader(Application.StartupPath + @"\positions.txt");
        string line;
        while ((line = tr.ReadLine()) != null) {
            if(line.Contains("Textbox X"))
                textX = int.Parse(line.Substring(0,4));
            else if (line.Contains("Textbox Y"))
                textY = int.Parse(line.Substring(0, 4));
            else if (line.Contains("Slider X"))
                sliderX = int.Parse(line.Substring(0, 4));
            else if (line.Contains("Slider Y"))
                sliderY = int.Parse(line.Substring(0, 4));
            else if (line.Contains("Submit X"))
                submitX = int.Parse(line.Substring(0, 4));
            else if (line.Contains("Submit Y"))
                submitY = int.Parse(line.Substring(0, 4));
        }
        tr.Close();
    }
