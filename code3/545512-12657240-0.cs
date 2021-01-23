    class EntityBase { }
    class Person : EntityBase {}
    interface EditableViewModel<out T> where T : EntityBase {} // Must be an interface. "out" marks T as a covariant parameter
    class PersonViewModel : EditableViewModel<Person> {}
    class CollectionViewModel<T> where T : EditableViewModel<EntityBase> { }
    class AllPersonsViewModel : CollectionViewModel<PersonViewModel> { }
