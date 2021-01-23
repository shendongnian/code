    using (FileStream fstream = new FileStream("path", FileMode.Open))
    using (StreamReader reader = new StreamReader(fstream)) {
        string line;
        while (!reader.EndOfStream && (line = reader.ReadLine()) != null) {
            string[] data = line.Split(',');
            if (data.Length < 5) {
                // You will have IndexOutOfRange issues
                continue; // skip processing the current loop
            }
            int employeeNumber;
            string employeeName;
            string employeeAddress;
            double employeeWage;
            double employeeHours;
            // Will be used to check validity of fields that require parsing into a type.
            bool valid;
            valid = int.TryParse(data[0], out employeeNumber);
            if (!valid) {
                // employee number is not parsable
            }
            employeeName = data[1];
            employeeAddress = data[2];
            valid = double.TryParse(data[3], out employeeWage);
            if (!valid) {
                // employee wage is not parsable
            }
            valid = double.TryParse(data[4], out employeeHours);
            if (!valid) {
                // employee hours are not parsable
            }
        }
    }
