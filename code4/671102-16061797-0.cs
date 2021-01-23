    string yeah = "0.5";
    float yeahFloat;
     if (float.TryParse(yeah,System.Globalization.NumberStyles.Any,
         System.Globalization.CultureInfo.InvariantCulture,out yeahFloat))
       {
         MessageBox.Show(yeahFloat.ToString());    
       }
