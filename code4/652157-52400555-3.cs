    public class BaseResponse<TData>
    {
        [JsonConverter(typeof(SingleValueToCollectionConverter))]
        public List<TData> Data { get; set; }
    }
