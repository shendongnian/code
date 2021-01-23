    public class Animal
    {
         public virtual Sound {get;}
    }
    public class Dog : Animal
    {
         public override Sound {get {return "Woof";}}
    }
    public class Cat : Animal
    {
         public override Sound {get {return "Meow";}}
    }
    public ActionResult MakeAnimalSound(Animal animal)
    {
       return PartialView("~/Views/_AnimalActionView.cshtml", new{sound=animal.Sound});
    }
