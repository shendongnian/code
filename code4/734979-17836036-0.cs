    public static string GenerateValues()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("DtoSelection selection = (DtoSelection)id;");
        sb.AppendLine("switch (selection)");
        foreach (DtoSelection value in (DtoSelection[])Enum.GetValues(typeof(DtoSelection))
        {
            sb.AppendLine("case DtoSelection." + value.ToString() + ":");
            sb.AppendLine("return new " + value.ToString() + ";");
        }
    }
