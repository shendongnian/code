    var controls = this.Controls.OfType<Label>().ToList();
    foreach(Label item in controls)
    {
         var index = Convert.ToInt32(item.Id.ToString().Replace("label","").Trim());
         var text =  Convert.ToString(values[index]);
         System.Console.WriteLine(text);
         item.Text =  text;
    }
