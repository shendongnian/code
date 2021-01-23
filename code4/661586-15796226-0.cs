    public class Person {
        public virtual BasePersonViewModel MainViewModel {
            get { return new BasePersonViewModel(this);}
        }
    }
    
    public class SuperHero : Person {
        public override BasePersonViewModel MainViewModel {
            get { return new BaseSuperHeroViewModel(this);}
        }
    }
