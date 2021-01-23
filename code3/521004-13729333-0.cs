          //Override this method to set the custom properties.
      public override object Clone()
      {
         var col = base.Clone() as BauerDataGridViewTextBoxColumn;
         col.ShowBorder = this.ShowBorder;
         col.BorderColor = this.BorderColor;
         col.ColumnChooserIsOptional = this.ColumnChooserIsOptional;
         col.ColumnChooserColumnLabel = this.ColumnChooserColumnLabel;
         return col;
      }
