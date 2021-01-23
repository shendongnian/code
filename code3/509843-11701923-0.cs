    public class Entity
    {
        protected int hp;
        protected string name;
        public Entity()
        {
            hp = 1;
            name = "entity";
        }
    
        public override string ToString()
        {
            string result = name + "#" + " HP:" + hp;
            return result;
        }
    }
	
    public class Dragon : Entity
    {
        public Dragon()
        {
            hp = 100;
            name = "Dragon";
        }
    }
