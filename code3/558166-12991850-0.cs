     private bool IsVehicle(Type type)
            {
                if (type.BaseType != null)
                    if (type.BaseType.FullName == "Vehicle")
                        return true;
                    else
                        IsVehicle(type.BaseType);
                return false;
            }
