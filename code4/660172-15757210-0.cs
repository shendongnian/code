<pre>
public interface IPersonRepository
{
    void SavePerson(Person p);
}
public class PersonServices
{
    PersonServices(IPersonRepository repo)
    {
      //
    }
    public void FirePerson(Person toFire)
    {
        toFire.FireHim();
        repo.SavePerson(toFire);
    }
}
</pre>
