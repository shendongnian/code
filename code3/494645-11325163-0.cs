        for(int i = 0; i < mytable.Rows.Count; i++)
            {
        string cssClass ;
        for(int j = 0; j < mytable.Rows[i].Cells.Count; j++)
        {
        cssClass = mytable.Rows[i].Cells[j].Attributes["class"];
         
           if(cssClass != null)
            {
              if(cssClass != String.Empty)
              {}
            }
         
        }
}
