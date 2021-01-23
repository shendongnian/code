    using UnityEngine;
    using System.Collections.Generic;
    using System.Collections;
    
    public class Player : MonoBehaviour
    {
    	public List<Item> Items = new List<Item>();
    
    	void Start()
    	{
    		Test();
    		
    		AddItem.Add( new ItemGenerator().GetRandomItem());
    		AddItem.Add( new ItemGenerator(ItemType.Weapon, "New Cool Weapon Item", UnityEngine.Random.Range(1,100),  UnityEngine.Random.Range(1,100)));
    		Item item = new Item();
    		item.ItemType = ItemType.Quest;
    		AddItem.Add(item);
    		AddItem.Add(new Item());
    		AddItem.Add( new ItemGenerator().GetRandomItem("Random Test Item 1 2 3"));
    		
    		AddItem.Add( item.Clone());
    	}
    	
    	public void AddItem(Item item)
    	{
    		Items.Add(item);
    	}
    	
    	void Test()
    	{
    		Debug.Log("Test starts");
    		// example flexibility
    		Item item = new Item();
    
    		item.ItemType = Itemtype.Weapon;
    		if(item.ItemType == Itemtype.Weapon)
    		   Debug.Log(item.WeaponProperties.GetDps(item));
    
    
    
    		item.ItemType = Itemtype.Armor;
    		if(item.ItemType == Itemtype.Armor)
    		   Debug.Log(item.ArmorProperties.Defense);
    
    
    		switch(item.ItemType)
    		{
    			case ItemType.Weapon: Debug.Log("Do Weapon Stuff - instantiate at weapon spawnpoint"); break;
    			case ItemType.Armor: Debug.Log("Do Armor Stuff - instantiate at spawnpoint"); break;
    			default: Debug.Log("what ever..."); break;
    		}
    		
    		// example item generator
    		Item item2 = new ItemGenerator(ItemType.Weapon);
    		Debug.Log(item2.Name);
    		
    		Item item3 = new ItemGenerator(ItemType.Armor, "New Armor Item");
    		Debug.Log(item3.Name);
    
    		item3.ItemType = ItemType.Weapon;
    		item3.Name = "Ultra Sword";
    		Debug.Log(item3.Name);
    		
    		Item item4 = new ItemGenerator(ItemType.Weapon, "New Weapon Item", UnityEngine.Random.Range(1,100),  UnityEngine.Random.Range(1,100));
    		Debug.Log(item3.Name);
    		
    		Item item5 = new ItemGenerator().GetRandomItem();
    		Debug.Log(item2.Name);
    		Debug.Log(item2.ItemType);
    		
    		// clone item
    		
    		Item item6 = item5.Clone();
    		Debug.Log(item2.Name);
    		
    		Debug.Log("Test ends");
    	}
    }
    
    
    public enum ItemType
    {
    	Weapon, Armor, Consumable, Quest, Key //...
    }
    
    public class Item // :ScriptableObject
    {
    	public string Name = "FooItem";
    	public ItemType Itemtype;
    	public Attributes Attributes = new Attributes();
    	public WeaponProperties WeaponProperties = new WeaponProperties();
    	public ArmorProperties ArmorProperties = new ArmorProperties();
    	public Item Clone()
        {
            return (Item)MemberwiseClone();
        }
    }
    
    [System.Serializable]
    public class WeaponProperties
    {
    	public int MinimalDamage = 10;
    	public int MaximalDamage= 20;
    	public float Speed = 1.5f;
    	public static float GetDps(Item weapon)
    	{
    		return Mathf.RoundToInt(((weapon.WeaponProperties.MinimalDamage + weapon.WeaponProperties.MaximalDamage) * 0.5f) / weapon.WeaponProperties.Speed);
    	}
    }
    [System.Serializable]
    public class ArmorProperties
    {
    	public int Defense = 25;
    }
    [System.Serializable]
    public class Attributes
    {
    	public int Strength = 25;
    	public int Stamina = 20;
    }
    
    public class ItemGenerator : Item
    {
    	public ItemGenerator(ItemType itemType) : this(itemType, "NewNamelessItem")
    	{
    	}
    	public ItemGenerator(ItemType itemType, string name)this(itemType, name, 0,  0)
    	{
    	}
    	public ItemGenerator(ItemType itemType, string name, int strength, int stamina) : this(itemType, name, strength, stamina,  0)
    	{
    	}
    	public ItemGenerator(ItemType itemType, string name, int strength, int stamina, int defense)
    	{
    		Name = name;
    		Attributes.Strength = strength;
    		Attributes.Stamina = stamina;
    		switch(item.ItemType)
    		{
    			case ItemType.Weapon: 
    				break;
    			case ItemType.Armor: 
    				ArmorProperties.Defense = defense;
    				break;
    			default: Debug.Log("what ever..."); break;
    		}
    	}
    	
    	public Item GetRandomItem()
    	{
    		return GetRandomItem( "New Random Item");
    	}
    	
    	public Item GetRandomItem(string name)
    	{
    		Name = name;
    		Attributes.Strength = Random.Range(0,100);
    		Attributes.Stamina = Random.Range(0,100);
    		var values = Enum.GetValues(typeof(ItemType));
            ItemType = (ItemType)values.GetValue(Random.Range(0, values.Length));
    		switch(item.ItemType)
    		{
    			case ItemType.Weapon: 
    				break;
    			case ItemType.Armor: 
    				ArmorProperties.Defense = Random.Range(0,100);
    				break;
    			default: Debug.Log("what ever..."); break;
    		}
    		return this;
    	}
    }
