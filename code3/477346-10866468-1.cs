    public class Animal 
    {
    	public string Name { get; private set; }
    	public double Weight { get; private set; }
    	public Habitat Habitat { get; private set; }
    
    	internal Animal(string name, double weight, Habitat habitat)
    	{
    		this.Name = name;
    		this.Weight = weight;
    		this.Habitat = habitat;
    	}
    
    	public void Swim();
    }
    
    public class SerializableAnimal
    {
    	public string Name { get; set; }
    	public double Weight { get; set; }
    	public SerializableHabitat Habitat { get; set; } //assuming the "Habitat" class is also immutable
    }
    
    public static class AnimalSerializer
    {
    	public static SerializableAnimal CreateSerializable(Animal animal)
    	{
    		return new SerializableAnimal {Name=animal.Name, Weight=animal.Weight, Habitat=HabitatSerializer.CreateSerializable(animal.Habitat)};
    	}
    
    	public static Animal CreateFromSerialized(SerializableAnimal serialized)
    	{
    		return new Animal(serialized.Name, serialized.Weight, HabitatSerializer.CreateFromSerialized(serialized.Habitat));
    	}
    
    	//or if you're using your "Static fields" design, you can switch/case on the name
    	public static Animal CreateFromSerialized(SerializableAnimal serialized)
    	{
    		switch (serialized.Name)
    		{
    			case "Otter" :
    				return Animal.Otter
    		}
    
    		return null; //or throw exception
    	}
    }
