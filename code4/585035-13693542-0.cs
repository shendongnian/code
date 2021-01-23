public Thingie Freeze(void) // Returns the object in question
{
  if (isFrozen) // Private field
    return this;
  else
    return DoFreeze();
}
Thingie DoFreeze(void)
{
  if (Monitor.TryEnter(whatever))
  {
    isFrozen = true;
    return this;
  }
  else if (isFrozen)
    return this;
  else
    throw new InvalidOperationException("Object in use by writer");
}
