	  object IDataRecord.GetValue(int i)
        {
            ValidateDataReader(DataReaderValidations.IsInitialized | DataReaderValidations.IsNotClosed);
            if (((IDataRecord)this).IsDBNull(i))
                return DBNull.Value;
            else
            {
                //For some reason the SqlBulkCopy.WriteToServer method will call this GetValue method when reading 
                //the value and it doesn't seem to know how to convert the string value of a Guid to a unique identifier.
                //However, it does actually know how to convert a System.Guid to a UniqueIdentifer so we can return that if
                //the value parses to Guid
                if (IsGuid(this[i]))
                    return Guid.Parse(this[i]);
                else
                    return this[i];
            }
        }
        bool IsGuid(object value)
        {
            if (value != null)
            {
                Guid testGuid = Guid.Empty;
                if (Guid.TryParse(value.ToString(), out testGuid))
                    return true;
            }
            return false;
        }
