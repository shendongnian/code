List&lt;IActOnConstrainedThing&lt;IThis,IThat>> _ActOnThingSubscribers;
void ActOnThings&lt;T>(T param) where T:IThis,IThat
{
  foreach(var thing in _ActOnThingSubscribers)
  {
    thing.Act&lt;T>(param);
  }
}
