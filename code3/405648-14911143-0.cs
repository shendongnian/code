    public abstract class Beverage
    {
        protected string m_description = "Unknown Beverage";
        public virtual string GetDescription()
        {
            return m_description;
        }
        public abstract double Cost();
    }
    public abstract class CondimentDecorator : Beverage
    {
    }
    public class Espresso : Beverage
    {
        public Espresso()
        {
            m_description = "Espresso";
        }
        public override double Cost()
        {
            return 1.99;
        }
    }
    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            m_description = "House Blend Coffe";
        }
        public override double Cost()
        {
            return 0.89;
        }
    }
    public class DarkRoast : Beverage
    {
        public DarkRoast()
        {
            m_description = "Dark Roast";
        }
        public override double Cost()
        {
            return 0.99;
        }
    }
    public class Mocha : CondimentDecorator
    {
        Beverage beverage;
        public Mocha(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Mocha";
        }
        public override double Cost()
        {
            return 0.20 + beverage.Cost();
        }
    }
    public class Soy : CondimentDecorator
    {
        Beverage beverage;
        public Soy(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Soy";
        }
        public override double Cost()
        {
            return 0.15 + beverage.Cost();
        }
    }
    public class Whip : CondimentDecorator
    {
        Beverage beverage;
        public Whip(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Whip";
        }
        public override double Cost()
        {
            return 0.10 + beverage.Cost();
        }
    }
