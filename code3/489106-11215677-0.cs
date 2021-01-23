        public class ObjectShader
        {
            
            public Effect effect;
    
            public System.Drawing.Image TextureImage;
    
            public string ShaderName;
    
            string TechniqueName;
      
    
                public ObjectShader(string name,Effect ef)
                {
                    this.ShaderName = name;
                    this.effect = ef;
                    
    
                }
    
    
                public void SetValue(string name, System.Drawing.Image val)
                {
                    this.TextureImage = val;
    
                }
    
    
    
                public void SetValue(string name,float val)
                {
                    this.effect.Parameters[name].SetValue(val);
    
                }
    
                public void SetValue(string name, float[] val)
                {
                    this.effect.Parameters[name].SetValue(val);
    
                }
    
    
                public void SetValue(string name, string val)
                {
                    this.effect.Parameters[name].SetValue(val);
    
                }
    
                public void SetValue(string name, Matrix val)
                {
                    this.effect.Parameters[name].SetValue(val);
    
                }
    
                public void SetValue(string name, Matrix[] val)
                {
                    this.effect.Parameters[name].SetValue(val);
    
                }
    
                public void SetValue(string name, Vector2 val)
                {
                    this.effect.Parameters[name].SetValue(val);
    
                }
    
                public void SetValue(string name, Vector2[] val)
                {
                    this.effect.Parameters[name].SetValue(val);
    
                }
    
                public void SetValue(string name, Vector3 val)
                {
                    this.effect.Parameters[name].SetValue(val);
    
                }
    
                public void SetValue(string name, Vector3[] val)
                {
                    this.effect.Parameters[name].SetValue(val);
    
                }
    
                public void SetValue(string name, int val)
                {
                    this.effect.Parameters[name].SetValue(val);
    
                }
                public void SetValue(string name, int[] val)
                {
                    this.effect.Parameters[name].SetValue(val);
    
                }
    
    
        }
    }
