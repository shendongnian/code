    public interface IExternalDllInterop
    {
        MB_STATUS queue_accept(int reader, string status);
    }
    public class AmbInterop : IAmbInterop
    {
        public MbStatus queue_accept(int reader, string status)
        {
            return StaticAmbInterop.mb_queue_accept(reader, message, status);
        }
    }
