       class Program {
          Person person;
          Action<Person> action;
          static void Main(string[] args) {
             Program p = new Program();
             p.Update();
    
             Console.ReadLine();
          }
          public void Update() {
             person = new Person();
    
             new Thread(() => {
                action = new Action<Person>(c => c.Name = "Sami");
             }).Start();
    
             Thread.Sleep(1000);
             action(person);
    
             Console.WriteLine(person.Name ?? "null");
          }
       }
    
       public class Person {
          public string Name;
       }
