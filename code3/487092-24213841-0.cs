        public static string ToHtmlTable<T>(this List<T> listOfClassObjects)
        {
            var ret = string.Empty;
            return listOfClassObjects == null || !listOfClassObjects.Any()
                ? ret
                : "<table>" +
                  listOfClassObjects.First().GetType().GetProperties().Select(p => p.Name).ToList().ToColumnHeaders() +
                  listOfClassObjects.Aggregate(ret, (current, t) => current + t.ToHtmlTableRow()) +
                  "</table>";
        }
        public static string ToColumnHeaders<T>(this List<T> listOfProperties)
        {
            var ret = string.Empty;
            return listOfProperties == null || !listOfProperties.Any()
                ? ret
                : "<tr>" +
                  listOfProperties.Aggregate(ret,
                      (current, propValue) =>
                          current +
                          ("<th style='font-size: 11pt; font-weight: bold; border: 1pt solid black'>" +
                           (Convert.ToString(propValue).Length <= 100
                               ? Convert.ToString(propValue)
                               : Convert.ToString(propValue).Substring(0, 100)) + "..." + "</th>")) +
                  "</tr>";
        }
        public static string ToHtmlTableRow<T>(this T classObject)
        {
            var ret = string.Empty;
            return classObject == null
                ? ret
                : "<tr>" +
                  classObject.GetType()
                      .GetProperties()
                      .Aggregate(ret,
                          (current, prop) =>
                              current + ("<td style='font-size: 11pt; font-weight: normal; border: 1pt solid black'>" +
                                         (Convert.ToString(prop.GetValue(classObject, null)).Length <= 100
                                             ? Convert.ToString(prop.GetValue(classObject, null))
                                             : Convert.ToString(prop.GetValue(classObject, null)).Substring(0, 100) +
                                               "...") +
                                         "</td>")) + "</tr>";
        }
