    ...
            PropertyInfo[] properties = obj.GetType().GetProperties();
            string CSVRow = "";
            foreach (PropertyInfo pi in properties)
            {
                CSVRow = CSVRow + pi.GetValue(obj, null) + ";";
            }
            CSVRow.Remove(CSVRow.Length - 1, 1);
    ...
