    public static IProfession CreateProffession(object dataObj)
            {
                if (dataObj == "Engineer")
                    return CreateProffession<Engineer>();
                if (dataObj == "Doctor")
                    return CreateProffession<Doctor>();
                throw new Exception("Not Implemented!");
            }
