    public interface IDoctor<TPatient> where T : IPerson<TPatient>
    {
    }
    
    public interface IPerson<T> where T : IPerson<T>
    {
        void VisitDoctor(IDoctor<T> doctor);
    }
    
    public class Adult : IPerson<Adult>
    {
        void VisitDoctor(IDoctor<Adult> doctor) {  }
    }
    public class AdultDoctor : IDoctor<Adult>
    {
    }
