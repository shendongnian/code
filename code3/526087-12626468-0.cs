    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var pagedList = new PagedList<MyObject>(
                                    new MyObject[] { 
                                        new MyObject { Foo = "Bar" }, 
                                        new MyObject { Foo = "Baz" } 
                                    }, 0, 2, 2);
                Debug.WriteLine(JsonConvert.SerializeObject(pagedList));
                // Outputs: [{"Foo":"Bar"},{"Foo":"Baz"}]
                var settings = new JsonSerializerSettings
                {
                    Converters = new List<JsonConverter>(
                                    new[]{
                                        new EnumerableConverter(
                                           new []{"ConsoleApplication2.PagedList"}, 
                                                  false)
                                    })
                };
                Debug.WriteLine(JsonConvert.SerializeObject(pagedList, settings));
                // Outputs: 
                //{
                //   "PageIndex":0,
                //   "PageSize":2,
                //   "TotalCount":2,
                //   "TotalPages":1,
                //   "HasPreviousPage":false,
                //   "HasNextPage":false,
                //   "Capacity":4,
                //   "Count":2,
                //   "Items":[
                //      {
                //         "Foo":"Bar"
                //      },
                //      {
                //         "Foo":"Baz"
                //      }
                //   ]
                //}      
            }
        }
        public class MyObject
        {
            public string Foo { get; set; }
        }
        public interface IPagedList : IEnumerable
        {
            int PageIndex { get; }
            int PageSize { get; }
            int TotalCount { get; }
            int TotalPages { get; }
            bool HasPreviousPage { get; }
            bool HasNextPage { get; }
        }
        public interface IPagedList<T> : IPagedList, IList<T>
        {
        }
        /// <summary>
        /// A tried and tested PagedList implementation
        /// </summary>
        public class PagedList<T> : List<T>, IPagedList<T>
        {
            //public PagedList(IEnumerable<T> source, int pageIndex, int pageSize) :
            //    this(source.GetPage(pageIndex, pageSize), pageIndex, pageSize, source.Count()) { }
            public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
            {
                //Ensure.Argument.NotNull(source, "source");
                this.TotalCount = totalCount;
                this.TotalPages = totalCount / pageSize;
                if (totalCount % pageSize > 0)
                    TotalPages++;
                this.PageSize = pageSize;
                this.PageIndex = pageIndex;
                this.AddRange(source.ToList());
            }
            public int PageIndex { get; private set; }
            public int PageSize { get; private set; }
            public int TotalCount { get; private set; }
            public int TotalPages { get; private set; }
            public bool HasPreviousPage { get { return (PageIndex > 0); } }
            public bool HasNextPage { get { return (PageIndex + 1 < TotalPages); } }
        }
        public class EnumerableConverter : Newtonsoft.Json.JsonConverter
        {
            private IEnumerable<string> Types { get; set; }
            private bool IsCamelCase { get; set; }
            public EnumerableConverter(IEnumerable<string> types)
                : this(types, true)
            {
            }
            public EnumerableConverter(IEnumerable<string> types, bool isCamelCase)
            {
                if (types == null) throw new ArgumentNullException("types");
                Types = types;
                IsCamelCase = isCamelCase;
            }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                writer.WriteStartObject();
                var foundInnerEnumerable = false;
                foreach (var property in value.GetType().GetProperties()) {
                    try {
                        var propVal = property.GetValue(value, null);
                        foundInnerEnumerable |= propVal is IEnumerable;
                        writer.WritePropertyName(NameFor(property.Name));
                        serializer.Serialize(writer, propVal);
                    }
                    catch (System.Reflection.TargetParameterCountException) { 
                        // Ignore properties such as Item on List<T>
                    }
                }
                if (!foundInnerEnumerable) {
                    writer.WritePropertyName(NameFor("Items"));
                    writer.WriteStartArray();
                    foreach (var item in (IEnumerable)value) {
                        serializer.Serialize(writer, item);
                    }
                    writer.WriteEndArray();
                }
                writer.WriteEndObject();
            }
            private string NameFor(string value)
            {
                if (!IsCamelCase) return value;
                return value[0].ToString().ToLowerInvariant() + value.Substring(1);
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
            public override bool CanConvert(Type objectType)
            {
                return Types.Any(t => objectType.FullName.StartsWith(t));
            }
        }
    }
