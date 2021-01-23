    public interface IDoctor<TPatient>
    {
        void SeePatient(TPatient patient);
    }
    public interface IAppointments<T>
    {
        void MakeAppointment(T patient, IDoctor<T> doctor);
    }
