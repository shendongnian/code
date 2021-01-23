interface ISomeProperties
  {int prop1 {get;set;}; string prop2 {get; set;}}
interface IMoreProperties
  {string prop3 {get;set;}; double prop4 {get; set;}}
interface ICombinedProperties : ISomeProperties, IMoreProperties; 
  { }
