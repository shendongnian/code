    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
...
    public class City
    {
        public int provinceid { get; set; }
        public string provincename { get; set; }
        public int cityid { get; set; }
        public string cityname { get; set; }
    }
    public void FindCity()
    {
        string json = @"[{ provinceid: ""1"", provincename: ""北京"", cityid: ""33"", cityname: ""北京"", jp: ""bj"", quanpin: ""beijing"" }, { provinceid: ""1"", provincename: ""北京"", cityid: ""600"", cityname: ""朝阳(北京)"", jp: ""cy"", quanpin: ""chaoyang"" }, { provinceid: ""1"", provincename: ""北京"", cityid: ""601"", cityname: ""通州(北京)"", jp: ""tz"", quanpin: ""tongzhou"" }, { provinceid: ""1"", provincename: ""北京"", cityid: ""46"", cityname: ""昌平"", jp: ""cp"", quanpin: ""changping"" }, { provinceid: ""1"", provincename: ""北京"", cityid: ""602"", cityname: ""顺义"", jp: ""sy"", quanpin: ""shunyi"" }]";
        List<City> cities = JsonConvert.DeserializeObject<List<City>>(json);
        City 北京 = cities.Where(city => city.cityname == "北京").First();
    }
