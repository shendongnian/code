    using System;
    using System.Runtime.CompilerServices;
    
    [AttributeUsage(AttributeTargets.Field)]
    public class EffectTypeAttribute : Attribute
    {
        public Type Type { get; private set; }
        
        public EffectTypeAttribute(Type type)
        {
            this.Type = type;
        }
    }
    
    public class LightningPowerup {}
    public class FirePowerup {}
    public class WaterPowerup {}
    
    public enum PowerupEffectType
    {
        [EffectType(typeof(LightningPowerup))]
        Lightning,
        [EffectType(typeof(FirePowerup))]
        Fire,
        [EffectType(typeof(WaterPowerup))]
        Water
    }
