    private void gridCaptions(FlexGrid gridName, Enum captionsEnum)
    {
            int i = 1;
            gridName.Cols.Count = Enum.GetValues(captionsEnum.GetType()).Length + 1;
            foreach (object value in Enum.GetValues(captionsEnum.GetType()))
            {
                gridName.Cols[i].Name = value.ToString();
                gridName[0, i] = classStatics.GetEnumDescription((Enum)value);
                i++;
            }
    }
