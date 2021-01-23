    <Element Name="ElementName">
      <ElementProperties.AttachedProperty>
        <MultiBinding>
          <Binding Path="B" />
          <Binding Path="C" />
        </MultiBinding>
      </ElementProperties.AttachedProperty>
      <Element.Property>
        <MultiBinding>
          <Binding Path="A" />       
          <Binding ElementName="ElementName" Path="(ElementProperties.AttachedProperty)" />
        </MultiBinding>
      </Element.Property>
    </Element>
