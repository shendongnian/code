    interface IWithRawCustomerType {
        int RawCustomerType {get;}
    }
    static class DtoExtensions {
        public static string GetCustomerType(this IWithRawCustomerType dto) {
            int type = dto.RawCustomerType;
            ...
        }
    }
    class CustomerDTO : IWithRawCustomerType {
        ...
    }
