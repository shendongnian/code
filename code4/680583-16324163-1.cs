    private void gridCaptions(FlexGrid anyGrid, Enum anyEnum)
    {
            int i = 1;
            anyGrid.Cols.Count = Enum.GetValues(anyEnum.GetType()).Length + 1;
            foreach (object value in Enum.GetValues(anyEnum.GetType()))
            {
                anyGrid.Cols[i].Name = value.ToString();
                anyGrid[0, i] = classStatics.GetEnumDescription((Enum)value);
                i++;
            }
    }
