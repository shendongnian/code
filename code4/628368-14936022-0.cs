    //In Class-scope:
    Color[] CollisionMapData;
    Texture2D CollisionMap;
    
    public void LoadContent()  
    {  
        CollisionMap = Content.Load<Texture2D>("map");  
        CollisionMapData = new Color[CollisionMap.Width * CollisionMap.Height];  
        CollisionMap.GetData<Color>(CollisionMapData);  
    }  
    
    public Boolean Collision(Vector2 position)  
    {  
        int index = (int)position.Y * CollisionMap.Width + (int)position.X;
        
        if (index < 0 || index >= CollisionMapData.Length) //Out of bounds  
            return true;
    
        if (CollisionMapData[index] == Color.Black)
            return true;
    
        return false;
    }
