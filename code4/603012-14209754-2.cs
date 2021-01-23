    public enum MyEnum
    {
        MyDictionaryKey1,
        MyDictionaryKey2,
        MyDictionaryKey3
    }
    ...
    <a href="@Url.Content("~/temp/Data/" + Model.Dict[MyApplication1.Models.MyEnum.MyDictionaryKey1.ToString()])"></a>
