// Assumes backing fields are named _Key and _Value
// Note that C# won't allow one to write private fields directly, but the
// act of copying one struct instance to another copies all the fields,
// public and private, from the source instance to the destination.
  KeyValuePair&lt;Wizzle, int&gt; temp;
  temp._Key = myKVP.Key; // Constructor has access to backing fields
  temp._Value = myKVP.Value+1;
  myKVP._Key = temp._Key; // Struct assignment copies all fields, public and private
  myKVP.Value = temp.Value;
