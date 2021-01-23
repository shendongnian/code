    public class VisualTypeConverter : EnumTypeConverter  
    {  
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)  
        {  
            return new StandardValuesCollection(new eVisualType[] { eVisualType.BlinkingStar, eVisualType.FireRed01, eVisualType.LaserBlackWhiteLeft, eVisualType.LaserBlackWhiteRight, eVisualType.LaserBlueRedLeft, eVisualType.LaserBlueRedRight, eVisualType.MovingPillar, eVisualType.Rune01, eVisualType.Rune02, eVisualType.Rune03, eVisualType.Torch, eVisualType.Wheel01, eVisualType.Wheel01a, eVisualType.Wheel02 });  
        }  
      
         public T GetEnumMemberFromName<T>(string name)
        {
            return (T)Enum.Parse(typeof(T), name);
        }
     
    }  
   
