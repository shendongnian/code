    public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
            {
                List<PropertyDescriptor> descriptors = new List<PropertyDescriptor>();
                foreach (PropertyDescriptor descriptor in this.GetProperties())
                {
                    bool include = false;
                    foreach (Attribute searchAttribute in attributes)
                    {
                        if (descriptor.Attributes.Contains(searchAttribute))
                        {
                            include = true;
                            break;
                        }
                    }
                    if (include)
                    {
                        descriptors.Add(descriptor);
                    }
                }
                return new PropertyDescriptorCollection(descriptors.ToArray());
            }
        }
