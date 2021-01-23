    class AnimatedEntity : DrawableEntity
    {
    	Dictionary<Orientation, Animation> Animations { get; set; }
        
        public AnimatedEntity()
        {
            Animations = new Dictionary<Orientation, Animation>();
        }
    	public Animation this[Orientation orientation] 
    	{ 
    		get{ return Animations[orientation]; }
    		set{ Animations[orientation] = value;}
    	}
    
    	Orientation Orientation { get; set; }
    
    	public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    	{
    		Animation anim = Animations[Orientation];
    	}
    }
