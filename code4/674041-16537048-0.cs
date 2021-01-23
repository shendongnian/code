    //Model
    public class Model
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        /*MultiSelect for this property*/
        public IEnumerable<ChildModel> Children { get; set; }        
    }
    //View
    @Html.Kendo().Grid<Model>()
      .Name("Grid")
      ...
      .DataSource(cfg => cfg
            .Ajax()
            .PageSize(20)
            .Model(c => c.Id(e => e.Id))
            .Update(c => c.Action("GridUpdate", "MyController").Data("getUpdateData"))
    )
    //JS
    var getUpdateData = function(data) {
        MultiSelectHelpers.serialize(data);
    };
    var MultiSelectHelpers = {
        serialize: function (data) {
            for (var property in data) {
                if ($.isArray(data[property])) {
                    this.serializeArray(property, data[property], data);
                }
            }
        },
        serializeArray: function (prefix, array, result) {
            for (var i = 0; i < array.length; i++) {
                if ($.isPlainObject(array[i])) {
                    for (var property in array[i]) {
                        result[prefix + "[" + i + "]." + property] = array[i][property];
                    }
                }
                else {
                    result[prefix + "[" + i + "]"] = array[i];
                }
            }
        }
    }
