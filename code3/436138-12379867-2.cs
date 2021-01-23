      internal class cmbKutoviNagiba : StringConverter
      {
            public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
            {
                return FALSE;    // <----- just highlight! remember to write it lowecase
            }
            public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                string[] a = { "0", "15", "30", "45", "60", "75", "90" };
                return new StandardValuesCollection(a);
            }
            public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            {
                return true;
            }
        }
