    public class BaseResponse<TData>
    {
        [JsonConverter(typeof(SingleValueCollectionConverter))]
        public List<TData> Data { get; set; }
    }
